﻿namespace Zone.Data.Data.Models;

public class Zone
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Note> Notes { get; set; }
    public List<User> Users { get; set; }
}