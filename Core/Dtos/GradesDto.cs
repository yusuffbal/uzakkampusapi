using Core.Entities;

public class GradesDto
{
    public Courses Course { get; set; }
    public double MidtermClassAverage { get; set; }
    public double FinalClassAverage { get; set; }
    public double? IntegrationClassAverage { get; set; }
    public double Average { get; set; }
    public double FinalNote { get; set; }
    public double? IntegrationNote { get; set; }
    public double MidtermNote { get; set; }
    public int Status { get; set; }
}
