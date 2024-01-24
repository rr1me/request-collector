using System.ComponentModel.DataAnnotations;

namespace requestCollector;

public class Request
{
	[Key]
	public int id { get; set; }
	
	public string? x_forwarded_for { get;set; }
	public string? x_forwarded_proto { get;set; }
	public string? x_forwarded_port { get;set; }
	public string? x_url { get;set; }
	public string? x_real_ip { get; set; }
	public string? host { get;set; }
	public string? x_amzn_trace_id { get;set; }
	public string? sec_ch_ua { get;set; }
	public string? origin { get;set; }
	public string? sec_ch_ua_mobile { get;set; }
	public string? user_agent { get;set; }
	public string? sec_ch_ua_platform { get;set; }
	public string? accept { get;set; }
	public string? sec_fetch_site { get;set; }
	public string? sec_fetch_mode { get;set; }
	public string? sec_fetch_dest { get;set; }
	public string? referer { get;set; }
	public string? accept_encoding { get;set; }
	public string? accept_language { get;set; }
	
	public DateTime date { get; set; }
}