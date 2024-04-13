﻿namespace Zone.Data.Data.Models;

public class Note
{
    public Guid Id { get; set; }
    public Guid ZoneId { get; set; }
    public ZoneLobby ZoneLobby { get; set; }
    public string Content { get; set; }
}