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
