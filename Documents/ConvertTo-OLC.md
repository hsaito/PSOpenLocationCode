---
external help file: PSOpenLocationCode.dll-Help.xml
Module Name: PSOpenLocationCode
online version:
schema: 2.0.0
---

# ConvertTo-OLC

## SYNOPSIS
Converts latitude and longitude data to Open Location Code.

## SYNTAX

### LongCode
```
ConvertTo-OLC [-Latitude] <Double> [-Longitude] <Double> [-Length <Int32>] [<CommonParameters>]
```

### ShortCode
```
ConvertTo-OLC [-Latitude] <Double> [-Longitude] <Double> -ReferenceLatitude <Double>
 -ReferenceLongitude <Double> [-Short] [<CommonParameters>]
```

## DESCRIPTION
The `ConvertTo-OLC` cmdlet converts numerical latitude and longitude pair into Open Location Code.

## EXAMPLES

### Example 1: Convert longitude 0.000000, latitude 0.000000 to Open Location Code
```powershell
ConvertTo-OLC 0.000000 0.000000
```

### Example 2: Generate shorter Open Location Code using reference coordinates
```powershell
ConvertTo-OLC 0.000000 0.000000 -Short -ReferenceLongitude 0.1 -ReferenceLatitude 0.1
```

## PARAMETERS

### -Latitude
Latitude to convert.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Longitude
Longitude to convert.

```yaml
Type: Double
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Length
Length of the code.

```yaml
Type: Int32
Parameter Sets: LongCode
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReferenceLatitude
Reference latitude for shorter code.

```yaml
Type: Double
Parameter Sets: ShortCode
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReferenceLongitude
Reference longitude for shorter code.

```yaml
Type: Double
Parameter Sets: ShortCode
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Short
Generate short code. (Requires reference latitude and longitude

```yaml
Type: SwitchParameter
Parameter Sets: ShortCode
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### System.String
Open Location Code.
## NOTES

## RELATED LINKS
[ConvertFrom-OLC](ConvertFrom-OLC)