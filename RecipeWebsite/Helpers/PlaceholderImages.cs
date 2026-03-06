namespace RecipeWebsite.Helpers;

public static class PlaceholderImages
{
    public static string GetForCategory(string? categoryName, int width = 400, int height = 200)
    {
        var svg = categoryName?.ToLowerInvariant() switch
        {
            "soups" or "soup" => SoupBowl,
            "salads" or "salad" => Salad,
            "desserts" or "dessert" or "baking" => Pie,
            "drinks" or "beverages" or "beverage" => Mug,
            "pasta" or "noodles" => Pasta,
            "breakfast" => FryingPan,
            "main course" or "main dishes" or "dinner" or "mains" => Pot,
            "appetizers" or "appetizer" or "snacks" or "sides" => Plate,
            _ => Pot
        };

        return $"data:image/svg+xml,{Uri.EscapeDataString(svg.Replace("{{W}}", width.ToString()).Replace("{{H}}", height.ToString()))}";
    }

    private const string Pot =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,100)'><ellipse cx='0' cy='30' rx='50' ry='12' fill='#4A7C59' opacity='0.12'/><rect x='-45' y='-20' width='90' height='50' rx='10' fill='#4A7C59' opacity='0.25'/><rect x='-50' y='-24' width='100' height='8' rx='4' fill='#4A7C59' opacity='0.4'/><rect x='-60' y='-22' width='12' height='16' rx='5' fill='none' stroke='#4A7C59' stroke-width='2.5' opacity='0.3'/><rect x='48' y='-22' width='12' height='16' rx='5' fill='none' stroke='#4A7C59' stroke-width='2.5' opacity='0.3'/><path d='M-15,-32 C-15,-38,-10,-42,-12,-50' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.2' stroke-linecap='round'/><path d='M0,-34 C0,-40,5,-44,3,-52' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.18' stroke-linecap='round'/><path d='M15,-32 C15,-38,10,-42,12,-50' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.2' stroke-linecap='round'/></g></svg>""";

    private const string Pie =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,105)'><ellipse cx='0' cy='20' rx='50' ry='12' fill='#D4A574' opacity='0.15'/><ellipse cx='0' cy='8' rx='48' ry='20' fill='#D4A574' opacity='0.35'/><ellipse cx='0' cy='-2' rx='48' ry='20' fill='#D4A574' opacity='0.2'/><path d='M-48,8 L-48,-2 A48,20 0 0,1 48,-2 L48,8' fill='#D4A574' opacity='0.25'/><path d='M-40,-6 Q-20,-18 0,-6 Q20,-18 40,-6' stroke='#D4A574' stroke-width='2.5' fill='none' opacity='0.4'/><path d='M-30,-2 Q-10,-14 10,-2 Q30,-14 40,-4' stroke='#D4A574' stroke-width='2' fill='none' opacity='0.3'/><line x1='0' y1='-22' x2='0' y2='8' stroke='#D4A574' stroke-width='1.5' opacity='0.2'/></g></svg>""";

    private const string SoupBowl =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,100)'><ellipse cx='0' cy='25' rx='50' ry='10' fill='#4A7C59' opacity='0.1'/><path d='M-50,0 Q-50,35 0,35 Q50,35 50,0' fill='#4A7C59' opacity='0.2'/><ellipse cx='0' cy='0' rx='50' ry='16' fill='#4A7C59' opacity='0.15'/><ellipse cx='-15' cy='-2' rx='6' ry='3' fill='#4A7C59' opacity='0.12'/><ellipse cx='12' cy='2' rx='5' ry='2.5' fill='#4A7C59' opacity='0.1'/><path d='M-15,-20 C-15,-26,-10,-30,-12,-38' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.15' stroke-linecap='round'/><path d='M0,-22 C0,-28,5,-32,3,-40' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.13' stroke-linecap='round'/><path d='M15,-20 C15,-26,10,-30,12,-38' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.15' stroke-linecap='round'/></g></svg>""";

    private const string Salad =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,100)'><ellipse cx='0' cy='25' rx='50' ry='10' fill='#4A7C59' opacity='0.1'/><path d='M-45,5 Q-45,30 0,30 Q45,30 45,5' fill='#4A7C59' opacity='0.15'/><ellipse cx='0' cy='5' rx='45' ry='15' fill='#4A7C59' opacity='0.12'/><circle cx='-12' cy='-2' r='8' fill='#4A7C59' opacity='0.2'/><circle cx='10' cy='0' r='7' fill='#4A7C59' opacity='0.18'/><circle cx='-2' cy='-8' r='6' fill='#4A7C59' opacity='0.22'/><circle cx='20' cy='-5' r='5' fill='#D4A574' opacity='0.25'/><circle cx='-22' cy='2' r='4' fill='#D4A574' opacity='0.2'/><path d='M-8,2 Q-6,-4 -2,0 Q2,-6 5,-1' stroke='#4A7C59' stroke-width='1.5' fill='none' opacity='0.2'/></g></svg>""";

    private const string Plate =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,100)'><ellipse cx='0' cy='15' rx='55' ry='14' fill='#4A7C59' opacity='0.08'/><ellipse cx='0' cy='10' rx='50' ry='22' fill='#4A7C59' opacity='0.12'/><ellipse cx='0' cy='8' rx='42' ry='18' fill='#4A7C59' opacity='0.08'/><ellipse cx='-8' cy='4' rx='12' ry='6' fill='#D4A574' opacity='0.2'/><ellipse cx='10' cy='6' rx='10' ry='5' fill='#4A7C59' opacity='0.15'/><circle cx='18' cy='0' r='4' fill='#D4A574' opacity='0.18'/></g></svg>""";

    private const string FryingPan =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(185,100)'><ellipse cx='0' cy='10' rx='45' ry='12' fill='#4A7C59' opacity='0.1'/><ellipse cx='0' cy='5' rx='42' ry='20' fill='#4A7C59' opacity='0.2'/><ellipse cx='0' cy='3' rx='36' ry='16' fill='#4A7C59' opacity='0.1'/><rect x='40' y='-4' width='35' height='8' rx='3' fill='#4A7C59' opacity='0.25'/><circle cx='-10' cy='0' r='6' fill='#D4A574' opacity='0.25'/><circle cx='8' cy='4' r='5' fill='#D4A574' opacity='0.2'/><circle cx='-5' cy='8' r='4' fill='#D4A574' opacity='0.18'/></g></svg>""";

    private const string Mug =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,105)'><ellipse cx='0' cy='25' rx='28' ry='6' fill='#4A7C59' opacity='0.1'/><rect x='-25' y='-20' width='50' height='48' rx='6' fill='#4A7C59' opacity='0.2'/><ellipse cx='0' cy='-20' rx='25' ry='6' fill='#4A7C59' opacity='0.12'/><path d='M25,-10 Q40,-10 40,5 Q40,18 25,18' stroke='#4A7C59' stroke-width='3' fill='none' opacity='0.25'/><path d='M-10,-28 C-10,-34,-5,-38,-7,-46' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.15' stroke-linecap='round'/><path d='M5,-28 C5,-34,10,-38,8,-46' stroke='#4A7C59' stroke-width='2' fill='none' opacity='0.13' stroke-linecap='round'/></g></svg>""";

    private const string Pasta =
        """<svg xmlns='http://www.w3.org/2000/svg' width='{{W}}' height='{{H}}' viewBox='0 0 400 200'><rect fill='#E8F0E4' width='400' height='200'/><g transform='translate(200,100)'><ellipse cx='0' cy='25' rx='50' ry='10' fill='#4A7C59' opacity='0.1'/><path d='M-45,5 Q-45,30 0,30 Q45,30 45,5' fill='#4A7C59' opacity='0.15'/><ellipse cx='0' cy='5' rx='45' ry='15' fill='#4A7C59' opacity='0.1'/><path d='M-20,-8 Q-10,8 0,-4 Q10,8 20,-8' stroke='#D4A574' stroke-width='3' fill='none' opacity='0.35'/><path d='M-15,-2 Q-5,12 5,0 Q15,12 25,-2' stroke='#D4A574' stroke-width='2.5' fill='none' opacity='0.3'/><path d='M-25,-5 Q-15,8 -5,-2 Q5,8 15,-5' stroke='#D4A574' stroke-width='2' fill='none' opacity='0.25'/><circle cx='-8' cy='2' r='3' fill='#4A7C59' opacity='0.2'/><circle cx='12' cy='0' r='2.5' fill='#4A7C59' opacity='0.18'/></g></svg>""";
}
