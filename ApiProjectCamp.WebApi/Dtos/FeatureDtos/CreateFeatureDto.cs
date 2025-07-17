namespace ApiProjectCamp.WebApi.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string FeatureTitle { get; set; }
        public string FeatureSubTitle { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureVideoUrl { get; set; }
        public string FeatureImageUrl { get; set; }
    }
}
