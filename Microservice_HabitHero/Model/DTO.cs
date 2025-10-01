﻿using System.ComponentModel.DataAnnotations;

namespace Microservice_HabitHero.Model
{
    public class DTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Você deve botar nomear o hábito")]
        public string? name { get; set; }
        [Required]
        [RegularExpression("^(bool|count)$", ErrorMessage = "goalType deve ser 'bool' ou 'count'.")]
        public string? goalType { get; set; }
        public int goal { get; set; }
        [Required(ErrorMessage = "Sua NameTag é obrigatória")]
        public string? clientId { get; set; }
    }
}
