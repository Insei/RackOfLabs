namespace RackOfLabs.Domain.Base;

public class TemplateEntity : BaseEntity
{
    /// <summary>
    /// Flag that this template is auto generated from our templates
    /// </summary>
    public bool Preset { get; set; }
    /// <summary>
    /// Flag that this template is modified by "hand"
    /// </summary>
    public bool Modified { get; set; }
}