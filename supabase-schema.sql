-- ============================================
-- Family Recipe Website — Supabase SQL Schema
-- ============================================
-- Run this in the Supabase SQL Editor (Dashboard > SQL Editor > New Query)
-- This creates all tables, RLS policies, storage bucket, and seed data.

-- 1. PROFILES TABLE (auto-created on user signup)
create table if not exists public.profiles (
    id uuid references auth.users on delete cascade primary key,
    display_name text not null default '',
    avatar_url text,
    created_at timestamptz not null default now()
);

alter table public.profiles enable row level security;

-- Anyone authenticated can read profiles
create policy "Profiles are viewable by authenticated users"
    on public.profiles for select
    to authenticated
    using (true);

-- Users can update their own profile
create policy "Users can update own profile"
    on public.profiles for update
    to authenticated
    using (auth.uid() = id);

-- Auto-create profile on signup
create or replace function public.handle_new_user()
returns trigger
language plpgsql
security definer set search_path = ''
as $$
begin
    insert into public.profiles (id, display_name)
    values (new.id, coalesce(new.raw_user_meta_data ->> 'display_name', split_part(new.email, '@', 1)));
    return new;
end;
$$;

create or replace trigger on_auth_user_created
    after insert on auth.users
    for each row execute procedure public.handle_new_user();


-- 2. CATEGORIES TABLE
create table if not exists public.categories (
    id serial primary key,
    name text not null unique,
    icon text
);

alter table public.categories enable row level security;

-- Anyone can read categories (even anonymous)
create policy "Categories are viewable by everyone"
    on public.categories for select
    using (true);

-- Seed categories
insert into public.categories (name, icon) values
    ('Mains', 'restaurant'),
    ('Desserts', 'cake'),
    ('Soups', 'soup_kitchen'),
    ('Salads', 'eco'),
    ('Sides', 'tapas'),
    ('Breakfast', 'free_breakfast'),
    ('Snacks', 'cookie'),
    ('Drinks', 'local_cafe'),
    ('Baking', 'bakery_dining'),
    ('Sauces', 'water_drop')
on conflict (name) do nothing;


-- 3. RECIPES TABLE
create table if not exists public.recipes (
    id serial primary key,
    title text not null,
    description text,
    ingredients jsonb not null default '[]'::jsonb,
    steps jsonb not null default '[]'::jsonb,
    image_path text,
    prep_time_minutes int,
    cook_time_minutes int,
    servings int,
    category_id int references public.categories(id) on delete set null,
    user_id uuid references auth.users(id) on delete cascade not null,
    created_at timestamptz not null default now(),
    updated_at timestamptz not null default now()
);

alter table public.recipes enable row level security;

-- Anyone authenticated can read recipes
create policy "Recipes are viewable by authenticated users"
    on public.recipes for select
    to authenticated
    using (true);

-- Authenticated users can create recipes
create policy "Authenticated users can create recipes"
    on public.recipes for insert
    to authenticated
    with check (auth.uid() = user_id);

-- Users can update their own recipes
create policy "Users can update own recipes"
    on public.recipes for update
    to authenticated
    using (auth.uid() = user_id);

-- Users can delete their own recipes
create policy "Users can delete own recipes"
    on public.recipes for delete
    to authenticated
    using (auth.uid() = user_id);

-- Auto-update updated_at
create or replace function public.update_updated_at()
returns trigger
language plpgsql
as $$
begin
    new.updated_at = now();
    return new;
end;
$$;

create or replace trigger recipes_updated_at
    before update on public.recipes
    for each row execute procedure public.update_updated_at();


-- 4. COMMENTS TABLE
create table if not exists public.comments (
    id serial primary key,
    recipe_id int references public.recipes(id) on delete cascade not null,
    user_id uuid references auth.users(id) on delete cascade not null,
    content text not null,
    created_at timestamptz not null default now()
);

alter table public.comments enable row level security;

-- Anyone authenticated can read comments
create policy "Comments are viewable by authenticated users"
    on public.comments for select
    to authenticated
    using (true);

-- Authenticated users can create comments
create policy "Authenticated users can create comments"
    on public.comments for insert
    to authenticated
    with check (auth.uid() = user_id);

-- Users can delete their own comments
create policy "Users can delete own comments"
    on public.comments for delete
    to authenticated
    using (auth.uid() = user_id);


-- 5. STORAGE BUCKET for recipe images
insert into storage.buckets (id, name, public)
values ('recipe-images', 'recipe-images', true)
on conflict (id) do nothing;

-- Anyone can read images (public bucket)
create policy "Recipe images are publicly accessible"
    on storage.objects for select
    using (bucket_id = 'recipe-images');

-- Authenticated users can upload images
create policy "Authenticated users can upload recipe images"
    on storage.objects for insert
    to authenticated
    with check (bucket_id = 'recipe-images');

-- Users can delete their own uploaded images
create policy "Users can delete own recipe images"
    on storage.objects for delete
    to authenticated
    using (bucket_id = 'recipe-images');


-- 6. INDEXES for performance
create index if not exists idx_recipes_user_id on public.recipes(user_id);
create index if not exists idx_recipes_category_id on public.recipes(category_id);
create index if not exists idx_recipes_created_at on public.recipes(created_at desc);
create index if not exists idx_comments_recipe_id on public.comments(recipe_id);
create index if not exists idx_recipes_title_search on public.recipes using gin(to_tsvector('english', title));
