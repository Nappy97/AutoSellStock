﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AutoStock.Data;

public partial class Token
{
    public int TokenId { get; set; }

    /// <summary>
    /// [10] 토큰분류
    /// </summary>
    public int TypeCode { get; set; }

    /// <summary>
    /// 토큰 값
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 사용 가능 여부
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 사용 종료일
    /// </summary>
    public DateTime ExpiredAt { get; set; }

    /// <summary>
    /// 특이사항
    /// </summary>
    public string Memo { get; set; }
}