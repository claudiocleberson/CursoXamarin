using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecord.Helpers
{
    public class Constants
    {
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?" +
                                            "&ll={0},{1}" +
                                            "&client_id={2}" +
                                            "&client_secret={3}" +
                                            "&v={4}";

        public const string CLIENTE_ID = "LCIPTZAG3XTST5OGYQ1B5JOJ0JKCJAIUF21QFWS3WU0NPAJ1";

        public const string CLIETEN_SECRET = "ORTBOZKKJ0YWDH5JP1KAHG0KAAIFKP0URTRCEHA0Q0TUGTAB";
    }
}
