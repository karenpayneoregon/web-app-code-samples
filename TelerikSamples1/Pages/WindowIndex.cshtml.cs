using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TelerikSamples1.Pages
{
    public class WindowIndexModel : PageModel
    {
        public string Text = string.Empty;
        public void OnGet()
        {
            Text =
                """
                <img src='images/earth.png' /><br/><br/>
                <strong>Frank Borman - One World</strong><br/><br/>
                The view of the earth from the moon fascinated me - a small disk, 240,000 mniles away. It was hard to think that that 
                little thing held so many problems, so many frustrations. <br/><br/>
                Raging nationalistic interests, famines, wars, 
                pestilence don't show from that distance. I'm convinced that some wayward stranger in a space-craft, coming 
                from some other part of the heavens, could look at earth and never know that it was inhabited at all. But the 
                same wayward stranger would certainly know instinctively that if the earth were inhabited, then the destinies of all 
                who lived on it must inevitably be interwoven and joined. We are one hunk of ground, water, air, clouds, floating around in space. 
                From out there it really is 'one world'.

                """;
            
        }
    }
}