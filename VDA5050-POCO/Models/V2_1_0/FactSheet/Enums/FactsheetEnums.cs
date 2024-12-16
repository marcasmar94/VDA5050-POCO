namespace VDA5050_POCO.Models.V2_1_0.FactSheet.Enums;
/// <summary>
/// Enum representing the kinematic type of the AGV.
/// </summary>
public enum AgvKinematic
{
    DIFF,
    OMNI,
    THREEWHEEL
}

/// <summary>
/// Enum representing the class of the AGV.
/// </summary>
public enum AgvClass
{
    FORKLIFT,
    CONVEYOR,
    TUGGER,
    CARRIER
}

/// <summary>
/// Enum representing the type of localization for the AGV.
/// </summary>
public enum LocalizationType
{
    NATURAL,
    REFLECTOR,
    RFID,
    DMC,
    SPOT,
    GRID
}

/// <summary>
/// Enum representing the type of navigation for the AGV.
/// </summary>
public enum NavigationType
{
    PHYSICAL_LINE_GUIDED,
    VIRTUAL_LINE_GUIDED,
    AUTONOMOUS
}