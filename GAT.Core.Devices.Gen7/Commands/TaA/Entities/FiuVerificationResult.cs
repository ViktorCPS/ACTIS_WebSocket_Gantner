namespace GAT.Core.Devices.Gen7.Commands.TaA.Entities
{
    /// <summary>
    /// All supported values of a fingerprint verification result.
    /// </summary>
    public enum FiuVerificationResult
    {
        NoVerification,
        Hit,
        NoHit,
        Timeout,
        NoTemplate,
        Error,
    }
}