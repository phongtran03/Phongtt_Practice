namespace Comsume_API.Models
{
    public class Coin {
        public string? id { get; set; }
        public string? symbol { get; set; }
        public string? name { get; set; }
        public string? image { get; set; }
        public float? current_price { get; set; }
        public string? market_cap { get; set; }
        public object? market_cap_rank { get; set; }
        public object? fully_diluted_valuation { get; set; }
        public float? total_volume { get; set; }
        public float? high_24h { get; set; }
        public float? low_24h { get; set; }
        public float? price_change_24h { get; set; }
        public float? price_change_percentage_24h { get; set; }
        public string? market_cap_change_24h { get; set; }
        public string? market_cap_change_percentage_24h { get; set; }
        public string? circulating_supply { get; set; }
        public float? total_supply { get; set; }
        public object? max_supply { get; set; }
        public long? ath { get; set; }
        public float? ath_change_percentage { get; set; }
        public DateTime? ath_date { get; set; }
        public float? atl { get; set; }
        public float? atl_change_percentage { get; set; }
        public DateTime? atl_date { get; set; }
        public object? roi { get; set; }
        public DateTime? last_updated { get; set; }
    }

}
