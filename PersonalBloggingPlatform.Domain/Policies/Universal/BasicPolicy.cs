namespace PersonalBloggingPlatform.Domain.Policies.Universal;

public class BasicPolicy : IBlogPostPolicy
{
    public bool IsApplicable(PolicyData policyData)
        => true;
}
