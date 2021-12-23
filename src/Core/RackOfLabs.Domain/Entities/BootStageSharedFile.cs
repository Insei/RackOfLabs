using RackOfLabs.Domain.Base;
#pragma warning disable CS8618

namespace RackOfLabs.Domain.Entities;

public class BootStageSharedFile : SharedFile
{
    /// <summary>
    /// Linked Boot stage
    /// </summary>
    public virtual BootStage BootStage { get; set; }
}