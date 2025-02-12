using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mission06_Matley.Models;

public class Application 
{
    [Key]
    [Required]
    public required string Category { get; set; }
    public required string Title { get; set; }
    public required string Year { get; set; }
    public required string Director { get; set; }
    public required string Rating { get; set; }
    public string? Edited { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
}