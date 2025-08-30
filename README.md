# PSOpenLocationCode

A PowerShell module for working with Open Location Code (Plus Codes) using the [Google.OpenLocationCode](https://github.com/google/open-location-code) library.

## Features
- Convert latitude/longitude to Open Location Code (OLC)
- Convert OLC back to latitude/longitude area
- Support for short codes with reference location
- Customizable code length

## Cmdlets

### ConvertTo-OLC
Converts latitude and longitude to an Open Location Code.

**Parameters:**
- `Latitude` (double, mandatory): Latitude to convert
- `Longitude` (double, mandatory): Longitude to convert
- `Length` (int, optional): Length of the code (default: 10)
- `ReferenceLatitude` (double, mandatory for short code): Reference latitude
- `ReferenceLongitude` (double, mandatory for short code): Reference longitude
- `Short` (switch, optional): Generate a short code

**Examples:**
```powershell
ConvertTo-OLC -Latitude 37.421908 -Longitude -122.084681
ConvertTo-OLC -Latitude 37.421908 -Longitude -122.084681 -Short -ReferenceLatitude 37.4 -ReferenceLongitude -122.08
```

### ConvertFrom-OLC
Converts an Open Location Code back to a geographic area.

**Parameters:**
- `Code` (string, mandatory): OLC code to convert
- `ReferenceLatitude` (double, mandatory for short code): Reference latitude
- `ReferenceLongitude` (double, mandatory for short code): Reference longitude
- `Short` (switch, optional): Indicates the code is a short code

**Examples:**
```powershell
ConvertFrom-OLC -Code "849VCWC8+R9"
ConvertFrom-OLC -Code "CWC8+R9" -Short -ReferenceLatitude 37.4 -ReferenceLongitude -122.08
```

## Installation

1. Build the project using .NET (see `.csproj` for details)
2. Import the module in PowerShell:
   ```powershell
   Import-Module ./PSOpenLocationCode/bin/Debug/net9.0/PSOpenLocationCode.dll
   ```

## Documentation
See the `Documents/` folder for detailed cmdlet usage and examples.

## License
This project is licensed under the [MIT License](./LICENSE).

It also incorporates the [Google.OpenLocationCode](https://github.com/google/open-location-code) library, which is licensed under the [Apache 2.0 License](https://www.apache.org/licenses/LICENSE-2.0).

---
For more information about Open Location Code, visit [https://plus.codes/](https://plus.codes/)
