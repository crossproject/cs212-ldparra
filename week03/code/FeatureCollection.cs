public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] Features { get; set; }

    public class Feature
    {
    public Property properties { get; set; }
    
        public class Property
        {
            public float mag { get; set; }
            public string place { get; set; }
        }
    }
    
}