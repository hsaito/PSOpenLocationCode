---
external help file: PSOpenLocationCode.dll-Help.xml
Module Name: PSOpenLocationCode
online version:
schema: 2.0.0
---

# ConvertFrom-OLC

## SYNOPSIS
Converts Open Location Code to numerical coordinates.

## SYNTAX

### LongCode
```
ConvertFrom-OLC [-Code] <String> [<CommonParameters>]
```

### ShortCode
```
ConvertFrom-OLC [-Code] <String> -ReferenceLatitude <Double> -ReferenceLongitude <Double> [-Short]
 [<CommonParameters>]
```

## DESCRIPTION
The `ConvertFrom-OLC` cmdlet generates numerical coordinates representation from Open Location Code.

## EXAMPLES

### Example 1: Convert Open Location Data for 6FG22222+22
```powershell
ConvertFrom-OLC 6FG22222+22
```

### Example 2: Convert short Open Location Code for 2222+22
```powershell
ConvertFrom-OLC 2222+22 -Short -ReferenceLongitude 0.1 -ReferenceLatitude 0.1
```

## PARAMETERS

### -Code
OLC code to convert from.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### Google.OpenLocationCode.CodeArea
## NOTES

## RELATED LINKS

[ConvertTo-OLC](ConvertTo-OLC)