# THE OYSTER CARD PROBLEM

## Problem Statement

You are required to model the following fare card system which is a limited version of London’s Oyster card system. At the end of the test, you should be able to demonstrate a user loading a card with £30, and taking the following trips, and then viewing the balance.

1. Tube Holborn to Earl’s Court
2. 328 bus from Earl’s Court to Chelsea
3. Tube from Earl’s court to Hammersmith

### OPERATION

* When the user passes through the inward barrier at the station, their oyster card is charged the maximum fare.
* When they pass out of the barrier at the exit station, the fare is calculated and the maximum fare transaction removed and replaced with the real transaction (in this way, if the user doesn’t swipe out, they are charged the maximum fare).
* All bus journeys are charged at the same price.
* The system should favour the customer where more than one fare is possible for a givenjourney. E.g. Holburn to Earl’s Court is charged at £2.50.

**ASSUME STATIONS ZONES ARE AS FOLLOWS:**

| Station | Zone(s) |
| --- | --- |
| Holborn | 1 |
| Aldgate | 1 |
| EarlsCourt | 1, 2 |
| Hammersmith | 2 |
| Arsenal | 2 |
| Wimbledon | 3 |

**ASSUME FARES ARE AS FOLLOWS:**

| Journey | Fare | Example |
| --- | --- | --- |
| Anywhere in Zone 1 | £2.50 | From Holborn to Aldgate |
| Any one zone outside zone 1 | £2.00 | From Arsenal to Hammersmith |
| Any two zones including zone 1 | £3.00 | From Hammersmith to Holborn |
| Any two zones excluding zone 1 | £2.25 | From Arsenal to Wimbledon |
| More than two zones (3+) | £3.20 | From Wimbledon to Aldgate |
| Any bus journey | £1.80 | Earl’s Court to Chelsea |

**OTHER CONSIDERATIONS**

* Any bus journey costs a flat rate of £1.80 regardless of the journey stations.
* The maximum possible fare is therefore £3.20

## Input Commands

### RECHARGE

RECHARGE command recharges wallet with the given amount.

syntax
``` bash
RECHARGE <amoount>
```

example
``` bash
RECHARGE 30
```

### ENTRY

ENTRY command registers entry to a purticular [station]() along with mode of transport.

syntax
``` bash
ENTRY <mode_of_transport> <station_name>
```

example
``` bash
ENTRY TUBE Holborn
```

### EXIT

EXIT command registers exit at a purticular [station]().

syntax
``` bash
EXIT <station_name>
```

example
``` bash
EXIT Aldgate
```

### BALANCE

BALANCE command returns current balance in the wallet. It doesn't take any other parameters.

syntax
``` bash
BALANCE
```

**stations** : Stations are preconfigured with zones and any other values other than given below will be rejected.

| Stations |
| --- |
| Holborn |
| Aldgate |
| EarlsCourt |
| Hammersmith |
| Arsenal |
| Wimbledon |

## Prerequisites

* [Dotnet 7.0](https://dotnet.microsoft.com/en-us/download)


## Build

 To run tests

 ``` bash
 dotnet build
 ```

 ## Test

 To run tests

 ``` bash
 dotnet test
 ```

 ## Run

 To run the application, either you can build and run the `.dll` file like

 ``` bash
 dotnet OysterCard/bin/Debug/net7.0/publish/OysterCard.dll <file_name>
 ```

 or you can using the below command

 ``` bash
  dotnet run --project OysterCard <file_name>
  ```

 The input file contains commands in order. For example:
  ``` bash
    RECHARGE 30
    ENTRY TUBE Holborn 
    EXIT EarlsCourt
    ENTRY BUS EarlsCourt
    ENTRY TUBE EarlsCourt
    EXIT Hammersmith
    BALANCE
  ```
