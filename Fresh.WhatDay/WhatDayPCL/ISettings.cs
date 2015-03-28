using System;

namespace WhatDayPCL
{
    public interface ISettings
    {
        DateTime StartDate { get; set; }

        event EventHandler Loaded;
    }
}