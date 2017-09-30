﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MyLondonUnderground.Application.Commands
{
    public abstract class BaseCommand : INotification
    {
        /// <summary>
        /// Needed by EF when scaffolding
        /// </summary>
        [ScaffoldColumn(false)]
        public int Id { get; set; } 
    }
}