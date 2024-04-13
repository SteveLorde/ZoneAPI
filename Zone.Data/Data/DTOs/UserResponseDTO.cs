﻿namespace Zone.Data.Data.DTOs;

public record UserResponseDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string JoinedOn { get; set; }
    public List<Models.Zone> Zones { get; set; }
};