﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AutoStock.Data;

public partial class AccountDetailHistory
{
    public int AccountDetailHistoryId { get; set; }

    public int AccountId { get; set; }

    public int StockId { get; set; }

    /// <summary>
    /// 개당 구매 가격
    /// </summary>
    public int PurchasePrice { get; set; }

    /// <summary>
    /// 구매 수량
    /// </summary>
    public int PurchaseQuantity { get; set; }

    /// <summary>
    /// 구매 시각
    /// </summary>
    public DateTime PurchasedAt { get; set; }

    /// <summary>
    /// 개당 판매 가격
    /// </summary>
    public int SellPrice { get; set; }

    /// <summary>
    /// 판매 수량
    /// </summary>
    public int SellQuantity { get; set; }

    /// <summary>
    /// 판매 시각
    /// </summary>
    public DateTime SoledAt { get; set; }

    /// <summary>
    /// 수익(수수료, 세금제외)
    /// </summary>
    public int? Profits { get; set; }

    public string Memo { get; set; }

    public virtual Account Account { get; set; }

    public virtual Stock Stock { get; set; }
}