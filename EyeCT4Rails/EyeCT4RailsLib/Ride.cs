namespace EyeCT4RailsLib
{
    public class Ride
    {
        /// <summary>
        /// The id of the ride in the database.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The line that the ride is on.
        /// </summary>
        public Line Line { get; }
        /// <summary>
        /// The user that is piloting the ride.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// The tram that is used for the ride.
        /// </summary>
        public Tram Tram { get; }

        /// <summary>
        /// Creates a ride.
        /// </summary>
        /// <param name="id">The id of the ride in the database.</param>
        /// <param name="line">The line that the ride is on.</param>
        /// <param name="user">The user that is piloting the ride.</param>
        /// <param name="tram">The tram that is used for the ride.</param>
        public Ride(int id, Line line, User user, Tram tram)
        {
            Id = id;
            Line = line;
            User = user;
            Tram = tram;
        }

        public override string ToString()
        {
            return $"{Id} - Line: {Line.Id} - Tram: {Tram.Id} - Driver: {User.Name}";
        }
    }
}
