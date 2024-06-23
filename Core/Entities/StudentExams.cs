using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

[Table("StudentExams")]
public class StudentExams : IEntity
{
    public int Id { get; set; }
    public int StudentID { get; set; }
    public int ExamId { get; set; }
    public float Point { get; set; }
    public int Status { get; set; }
    public DateTime DateOfStart { get; set; }
    public DateTime DateOfEnd { get; set; }
    public int Type { get; set; }

    [ForeignKey("StudentID")]
    public virtual Users Student { get; set; }

    [ForeignKey("ExamId")]
    public virtual Exams Exam { get; set; }
}
