﻿namespace BasketService.Models.DTO
{
    public class BasketDto
    {
        public string Identifier { get; set; }
        public ICollection<BasketItemDto> BasketItem { get; set; }
    }
}
