@{
    RootModule = 'PSOpenLocationCode.dll'
    ModuleVersion = '1.2.0.0'
    FunctionsToExport = @(
    'ConvertTo-OLC'
    'ConvertFrom-OLC'
    )
    CmdletsToExport = '*'
    VariablesToExport = '*'
    AliasesToExport = '*'
    GUID = 'd3bdc2ff-d807-4e78-afd1-73821d74d82d'
    Author = 'Hideki Saito'
    Description = 'Open Location Code (also known as Plus codes) Module for PowerShell'
    PowerShellVersion = '6.0'
    CompatiblePSEditions = 'Core'
    Copyright = '(c) 2019 Hideki Saito. All rights reserved.'
    PrivateData = @{
        PSData = @{
            ProjectUri = 'https://github.com/hsaito/PSOpenLocationCode/'
            ReleaseNotes = ''
        }
    }
}