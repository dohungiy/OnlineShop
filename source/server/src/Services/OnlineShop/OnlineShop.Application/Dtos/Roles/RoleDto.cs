﻿namespace OnlineShop.Application.Dtos;

public class RoleDto
{
    public string Id { get; set; }
    
    public string RoleCode { get; set; }
    
    public string RoleName { get; set; }
    
    public IEnumerable<ActionDto> Actions { get; set; }
}