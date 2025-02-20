using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Mission06_Matley.Models;

public class Movies 
{
    [Key] [Required] public int MovieId { get; set; }
    
    [Required] [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required] public string Title { get; set; }
    
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required] public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required] public bool CopiedToPlex { get; set; }
    [MaxLength(25)] public string? Notes { get; set; }
}