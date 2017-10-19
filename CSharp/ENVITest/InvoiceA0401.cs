using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENVITest
{
    class InvoiceA0401
    {
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string InvoiceNumber;

        /// <summary>
        /// 發票產生日期
        /// </summary>
        public string InvoiceDate;
        
        /// <summary>
        /// 發票產生時間
        /// </summary>
        public string InvoiceTime;

        /// <summary>
        /// 賣方-營業人統一編號
        /// </summary>
        public string SellerIdentifier;


        /// <summary>
        /// 賣方-營業人名稱
        /// </summary>
        public string SellerName;


        /// <summary>
        /// 買方-營業人統一編號
        /// </summary>
        public string BuyerIdentifier;

        /// <summary>
        /// 買方-營業人名稱
        /// </summary>
        public string BuyerName;


        /// <summary>
        /// 發票類別  詳細定義請參考InvoiceTypeEnum 資料元規格
        ///  01：三聯式
        /// 02：二聯式
        /// 03：二聯式收銀機
        /// 04：特種稅額
        /// 05：電子計算機
        /// 06：三聯式收銀機
        /// 07：一般稅額計算之電子發票
        /// 08：特種稅額計算之電子發票
        /// </summary>
        /// 
        public string InvoiceType;

        /// <summary>
        /// 彙開註記(選項)   彙開需要填入"*" 
        /// </summary>
        public string GroupMark;

        /// <summary>
        /// 捐贈註記  詳細定義請參考DonateMarkEnum 資料元規格
        /// </summary>
        public string DonateMark;
        
        /// <summary>
        /// 發票金額
        /// </summary>
        public string SalesAmount;

        /// <summary>
        /// 稅 類別
        /// </summary>
        public string TaxType;

        /// <summary>
        /// 稅制
        /// </summary>
        public string TaxRate;

        /// <summary>
        /// 稅額
        /// </summary>
        public string TaxAmount;

        /// <summary>
        /// 發票含稅
        /// </summary>
        public string TotalAmount;

        /// <summary>
        /// 折讓金額
        /// </summary>
        public string DiscountAmount;

        /// <summary>
        /// 外幣原幣金額 (選項)
        /// </summary>
        public string OriginalCurrencyAmount;

        /// <summary>
        /// 匯率 (選項)
        /// </summary>
        public string ExchangeRate;

        public List<InvoiceA0401ProductItem> ProductItems;

    }
}
