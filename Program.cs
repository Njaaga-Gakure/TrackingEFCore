using TrackingEFCore.Data;
using TrackingEFCore.Models;

try
{
    using TrackingContext context = new TrackingContext();
    // Usage: Comment to Test Each Section

    // added state
    Trainee trainee = new Trainee()
    {
        Name = "kush",
        Email = "kushnjaaga@gmail.com"
    };
    Console.WriteLine($"before add is called: {context.Entry(trainee).State}");
    context.Trainees.Add(trainee);
    Console.WriteLine($"before savechanges is called: {context.Entry(trainee).State}");
    context.SaveChanges();
    Console.WriteLine($"after savechanges is called: {context.Entry(trainee).State}");
    Console.WriteLine("trainee was added successfully");

    // unchanged state

    var unchangedTrainee = context.Trainees.FirstOrDefault(trainee => trainee.Id == 1);

    if (unchangedTrainee != null)
    {
        Console.WriteLine($"Name: {unchangedTrainee.Name} | Email: {unchangedTrainee.Email}");
        Console.WriteLine();
        Console.WriteLine($"Before SaveChanges is called: {context.Entry(unchangedTrainee).State}");
        context.SaveChanges();
        Console.WriteLine($"After SaveChanges is called: {context.Entry(unchangedTrainee).State}");
    }


    // modified state

    var updateTrainee = (from t in context.Trainees
                         where t.Id == 2
                         select t).FirstOrDefault();
    if (updateTrainee != null)
    {
        Console.WriteLine($"Before modification: {context.Trainees.Entry(updateTrainee).State}");
        updateTrainee.Email = "gakurenjaaga@gmail.com";
        Console.WriteLine($"After modification: {context.Trainees.Entry(updateTrainee).State}");
        context.SaveChanges();

        Console.WriteLine($"After SaveChanges is called: {context.Trainees.Entry(updateTrainee).State}");

    }

    // deleted state
    var removeTrainee = (from tr in context.Trainees
                         where tr.Id == 2
                         select tr).FirstOrDefault();
    if (removeTrainee != null)
    {
        Console.WriteLine($"Before Remove method is called: {context.Trainees.Entry(removeTrainee).State}");
        context.Trainees.Remove(removeTrainee );
        Console.WriteLine($"After Remove is called: {context.Trainees.Entry(removeTrainee).State}");
        context.SaveChanges();
        Console.WriteLine($"After SaveChanges is called: {context.Trainees.Entry(removeTrainee).State}");


    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

