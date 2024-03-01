﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AutoStock.Data;

public partial class Stock
{
    public int StockId { get; set; }

    /// <summary>
    /// 주식 이름
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 거래를 위한 상품코드
    /// </summary>
    public string StockCode { get; set; }

    /// <summary>
    /// 자동매매 포함 여부
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// [11] 주식 상장 국가
    /// </summary>
    public int NationalityCode { get; set; }

    /// <summary>
    /// [12] 주식 상장 위치(코스피, 코스닥)
    /// </summary>
    public int LocationCode { get; set; }

    /// <summary>
    /// 특이사항
    /// </summary>
    public string Memo { get; set; }

    public virtual ICollection<AccountDetailHistory> AccountDetailHistories { get; set; } = new List<AccountDetailHistory>();

    public virtual ICollection<AccountDetail> AccountDetails { get; set; } = new List<AccountDetail>();
}