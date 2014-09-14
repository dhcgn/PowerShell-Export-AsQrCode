PowerShell-Export-AsQrCode
==========================

PowerShell Module to create QrCodes from text.

More information see wiki https://github.com/dhcgn/PowerShell-Export-AsQrCode/wiki
Downloads: https://github.com/dhcgn/PowerShell-Export-AsQrCode/releases

Simple Usage
--------------

    PS C:\> Export-AsQrCode Hallo
    C:\Users\User\Pictures\QrCodes\8b0e28a8-61e6-4406-ab7e-fba284c49f38.png

Result: http://i.imgur.com/GtCLbdf.png

Full Usage
--------------

    PS C:\> Export-AsQrCode -Text Hallo -OutputPath C:\temp\QrCode.png `
    >>> -OpenWithShellExtension `
    >>> -ErrorCorrectionLevel H `
    >>> -ModuleSize 16 `
    >>> -DarkBrush Brown `
    >>> -LightBrush Yellow
    C:\temp\QrCode.png

Result: http://i.imgur.com/8kAIGHi.png

Supported colors: http://msdn.microsoft.com/de-de/library/aa358802%28vs.85%29.aspx

Get-Help
--------------

    PS C:\> get-help Export-AsQrCode
    
    NAME
        Export-AsQrCode
    
    SYNTAX
        Export-AsQrCode [-Text] <string> [[-OutputPath] <string>] [-OpenWithShellExtension] [-ErrorCorrectionLevel <string> {L | M | Q | H}] [-ModuleSize <int>]
    [-DarkBrush <string> {Transparent | AliceBlue | AntiqueWhite | Aqua | Aquamarine | Azure | Beige | Bisque | Black | BlanchedAlmond | Blue | BlueViolet |
    Brown | BurlyWood | CadetBlue | Chartreuse | Chocolate | Coral | CornflowerBlue | Cornsilk | Crimson | Cyan | DarkBlue | DarkCyan | DarkGoldenrod |
    DarkGray | DarkGreen | DarkKhaki | DarkMagenta | DarkOliveGreen | DarkOrange | DarkOrchid | DarkRed | DarkSalmon | DarkSeaGreen | DarkSlateBlue |
    DarkSlateGray | DarkTurquoise | DarkViolet | DeepPink | DeepSkyBlue | DimGray | DodgerBlue | Firebrick | FloralWhite | ForestGreen | Fuchsia | Gainsboro |
    GhostWhite | Gold | Goldenrod | Gray | Green | GreenYellow | Honeydew | HotPink | IndianRed | Indigo | Ivory | Khaki | Lavender | LavenderBlush |
    LawnGreen | LemonChiffon | LightBlue | LightCoral | LightCyan | LightGoldenrodYellow | LightGreen | LightGray | LightPink | LightSalmon | LightSeaGreen |
    LightSkyBlue | LightSlateGray | LightSteelBlue | LightYellow | Lime | LimeGreen | Linen | Magenta | Maroon | MediumAquamarine | MediumBlue | MediumOrchid
    | MediumPurple | MediumSeaGreen | MediumSlateBlue | MediumSpringGreen | MediumTurquoise | MediumVioletRed | MidnightBlue | MintCream | MistyRose |
    Moccasin | NavajoWhite | Navy | OldLace | Olive | OliveDrab | Orange | OrangeRed | Orchid | PaleGoldenrod | PaleGreen | PaleTurquoise | PaleVioletRed |
    PapayaWhip | PeachPuff | Peru | Pink | Plum | PowderBlue | Purple | Red | RosyBrown | RoyalBlue | SaddleBrown | Salmon | SandyBrown | SeaGreen | SeaShell
    | Sienna | Silver | SkyBlue | SlateBlue | SlateGray | Snow | SpringGreen | SteelBlue | Tan | Teal | Thistle | Tomato | Turquoise | Violet | Wheat | White
    | WhiteSmoke | Yellow | YellowGreen}] [-LightBrush <string> {Transparent | AliceBlue | AntiqueWhite | Aqua | Aquamarine | Azure | Beige | Bisque | Black |
    BlanchedAlmond | Blue | BlueViolet | Brown | BurlyWood | CadetBlue | Chartreuse | Chocolate | Coral | CornflowerBlue | Cornsilk | Crimson | Cyan |
    DarkBlue | DarkCyan | DarkGoldenrod | DarkGray | DarkGreen | DarkKhaki | DarkMagenta | DarkOliveGreen | DarkOrange | DarkOrchid | DarkRed | DarkSalmon |
    DarkSeaGreen | DarkSlateBlue | DarkSlateGray | DarkTurquoise | DarkViolet | DeepPink | DeepSkyBlue | DimGray | DodgerBlue | Firebrick | FloralWhite |
    ForestGreen | Fuchsia | Gainsboro | GhostWhite | Gold | Goldenrod | Gray | Green | GreenYellow | Honeydew | HotPink | IndianRed | Indigo | Ivory | Khaki |
    Lavender | LavenderBlush | LawnGreen | LemonChiffon | LightBlue | LightCoral | LightCyan | LightGoldenrodYellow | LightGreen | LightGray | LightPink |
    LightSalmon | LightSeaGreen | LightSkyBlue | LightSlateGray | LightSteelBlue | LightYellow | Lime | LimeGreen | Linen | Magenta | Maroon |
    MediumAquamarine | MediumBlue | MediumOrchid | MediumPurple | MediumSeaGreen | MediumSlateBlue | MediumSpringGreen | MediumTurquoise | MediumVioletRed |
    MidnightBlue | MintCream | MistyRose | Moccasin | NavajoWhite | Navy | OldLace | Olive | OliveDrab | Orange | OrangeRed | Orchid | PaleGoldenrod |
    PaleGreen | PaleTurquoise | PaleVioletRed | PapayaWhip | PeachPuff | Peru | Pink | Plum | PowderBlue | Purple | Red | RosyBrown | RoyalBlue | SaddleBrown
    | Salmon | SandyBrown | SeaGreen | SeaShell | Sienna | Silver | SkyBlue | SlateBlue | SlateGray | Snow | SpringGreen | SteelBlue | Tan | Teal | Thistle |
    Tomato | Turquoise | Violet | Wheat | White | WhiteSmoke | Yellow | YellowGreen}]  [<CommonParameters>]


    ALIASES
        None


    REMARKS
        None


