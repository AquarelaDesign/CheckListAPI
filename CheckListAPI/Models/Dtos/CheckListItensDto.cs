﻿namespace CheckListAPI.Models.Dtos
{
    public class CheckListItensDto
    {
        public int Id { get; set; }
        public required int GroupId { get; set; }
        public required string Description { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; } = false;
    }
}
