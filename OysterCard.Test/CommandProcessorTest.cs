namespace OysterCard.Test;

public class CommandProcessorTest
{
    [Fact]
    public void TestCase_should_raise_exception_for_invalid_command()
    {
        var commands = new List<string>() {
            "RETRIEVE 30"
        };

        var exception = Assert.Throws<Exception>(() =>
        {
            CommandProcessor.ProcessCommands(commands);
        });

        Assert.Equal("INVALID COMMAND PROVIDED: RETRIEVE", exception.Message);
    }

    [Fact]
    public void TestCase_should_raise_exception_for_invalid_location()
    {
        var commands = new List<string>() {
            "ENTRY TUBE Richmond"
        };

        var exception = Assert.Throws<Exception>(() =>
        {
            CommandProcessor.ProcessCommands(commands);
        });

        Assert.Equal("Invalid location: Richmond", exception.Message);
    }

    [Fact]
    public void TestCase_should_raise_exception_for_insufficient_amount_in_wallet()
    {
        var commands = new List<string>() {
            "RECHARGE 1.00",
            "ENTRY BUS Holborn"
        };

        var exception = Assert.Throws<Exception>(() =>
        {
            CommandProcessor.ProcessCommands(commands);
        });

        Assert.Equal("Insufficient Fund in wallet", exception.Message);
    }

    [Fact]
    public void TestCase_travel_within_zone_one()
    {
        var commands = new List<string>() {
            "RECHARGE 30",
            "ENTRY TUBE Holborn",
            "EXIT TUBE Aldgate",
            "BALANCE"
        };

        var response = CommandProcessor.ProcessCommands(commands);

        Assert.Single(response);
        Assert.Equal("27.50", response.First());
    }

    [Fact]
    public void TestCase_example_given_in_the_problem_statement()
    {
        var commands = new List<string>() {
            "RECHARGE 30",
            "ENTRY TUBE Holborn",
            "EXIT TUBE EarlsCourt",
            "ENTRY BUS EarlsCourt",
            "ENTRY TUBE EarlsCourt",
            "EXIT TUBE Hammersmith",
            "BALANCE"
        };

        var response = CommandProcessor.ProcessCommands(commands);

        Assert.Single(response);
        Assert.Equal("22.20", response.First());
    }

    [Fact]
    public void TestCase_entry_without_exit_charges_max_fare()
    {
        var commands = new List<string>() {
            "RECHARGE 30",
            "ENTRY TUBE Holborn",
            "BALANCE"
        };

        var response = CommandProcessor.ProcessCommands(commands);

        Assert.Single(response);
        Assert.Equal("26.80", response.First());
    }

    [Fact]
    public void TestCase_travel_within_zones_station_falls_in_multiple_zones()
    {
        var commands = new List<string>() {
            "RECHARGE 30",
            "ENTRY TUBE Holborn",
            "EXIT TUBE EarlsCourt",
            "BALANCE",
            "ENTRY TUBE EarlsCourt",
            "EXIT TUBE Hammersmith",
            "BALANCE"
        };

        var response = CommandProcessor.ProcessCommands(commands);

        Assert.Equal(2, response.Count);
        Assert.Equal("27.00", response.First());
        Assert.Equal("24.00", response.Last());
    }
}