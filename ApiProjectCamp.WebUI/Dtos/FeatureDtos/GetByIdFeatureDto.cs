namespace ApiProjectCamp.WebUI.Dtos.FeatureDtos
{
    public class GetByIdFeatureDto
    {
        public int FeatureId { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureSubTitle { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureVideoUrl { get; set; }
        public string FeatureImageUrl { get; set; }
    }
}
