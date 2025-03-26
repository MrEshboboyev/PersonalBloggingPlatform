namespace PersonalBloggingPlatform.Domain.Policies;

public interface IBlogPostPolicy
{
    bool IsApplicable(PolicyData policyData);
}
