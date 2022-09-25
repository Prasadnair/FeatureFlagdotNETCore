using Microsoft.FeatureManagement;

namespace FeatureFlagTutorial.Filters
{
    [FilterAlias("Browser")]
    public class BrowserFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BrowserFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            if(_httpContextAccessor.HttpContext !=null)
            {
                var userAgent = _httpContextAccessor
                                        .HttpContext
                                        .Request.Headers["User-Agent"].ToString();

                var _browserSettings = context.Parameters.Get<BrowserFilterSettings>();
                return Task.FromResult(_browserSettings.Allowed.Any(x => userAgent.Contains(x)));
            }
            return Task.FromResult(false);
        }
    }
    
}
