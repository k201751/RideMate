using Microsoft.AspNetCore.Mvc;
using RideMate.Models;

public class RideController : Controller
{
    private static List<Ride> Rides = new List<Ride>();

    // Display the AddRide form
    [HttpGet]
    public IActionResult AddRide()
    {
        return View();
    }

    // Handle form submission for adding a new ride
    [HttpPost]
    public IActionResult AddRide(Ride ride)
    {
        if (ModelState.IsValid)
        {
            // Add the ride to the list
            Rides.Add(ride);
            return RedirectToAction("Index");  // Redirect to the Index action
        }

        // If validation fails, return to the AddRide view with the model
        return View(ride);
    }

    // Display all rides (Index)
    public IActionResult Index()
    {
        return View(Rides);  // Returns all the rides
    }
    [HttpGet]
    public ActionResult UpdateRide(int id)
    {
        var ride = Rides.FirstOrDefault(r => r.Id == id);  // Find the ride by Id
        if (ride == null)
        {
            return NotFound(); // If the ride doesn't exist, return a 404 error
        }
        return View(ride); // Pass the ride to the view for editing
    }

    // POST: Edit Ride (submit the changes to update the ride)
    [HttpPost]
    public ActionResult UpdateRide(Ride ride)
    {
        var existingRide = Rides.FirstOrDefault(r => r.Id == ride.Id);
        if (existingRide == null)
        {
            return NotFound(); // If the ride is not found, return 404
        }

        // Update the ride's details
        existingRide.StartingLocation = ride.StartingLocation;
        existingRide.Destination = ride.Destination;
        existingRide.Date = ride.Date;
        existingRide.Time = ride.Time;
        existingRide.AvailableSeats = ride.AvailableSeats;

        return RedirectToAction("Index"); // Redirect back to the list of rides after update
    }
    public ActionResult DeleteRide(int id)
    {
        var ride = Rides.FirstOrDefault(r => r.Id == id);
        if (ride != null)
        {
            Rides.Remove(ride);  // Remove the ride from the list
        }
        return RedirectToAction("Index");  // Redirect back to the Index view to show the updated list
    }
}
