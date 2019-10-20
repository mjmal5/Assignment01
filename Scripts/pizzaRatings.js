
$(document).ready(function () {

    var Id = [];
    var Name = [];
    var graphData = []

    $.getJSON("NameData", function (data) {

        var arrItems = [];

        //Convert JSON data to Javascript array
        $.each(data, function (index, value) {
            arrItems.push(value);
        });

        //Split Array into Id and PizzaId arrays
        for (i = 0; i < arrItems.length; i++) {
            Id[i] = arrItems[i].Id;
            Name[i] = arrItems[i].Name;
        }

        //console.log("Id: " + Id);
        //console.log("Name: " + Name);
        
    });


    $.getJSON("RatingData", function (data) {

        var arrItems = [];
        var Rating = [];
        var PizzaId = [];
        var CombinedRating = [];
        var Count = [];
        var FinalRatings = [];

        //Convert JSON data to Javascript array
        $.each(data, function (index, value) {
            arrItems.push(value);
        });

        //Split Array into Rating and PizzaId arrays
        for (i = 0; i < arrItems.length; i++) {
            Rating[i] = arrItems[i].Rating;
            PizzaId[i] = arrItems[i].PizzaId;
        }

        //Get array of unique Pizza IDs
        UniquePizzaID = PizzaId.filter(function (value, index, array) {
            return array.indexOf(value) == index;
        });

        //Get count of individual pizza rating and add the pizza ratings together
        for (x = 0; x < UniquePizzaID.length; x++) {

            CombinedRating[x] = 0;
            Count[x] = 0;

            for (i = 0; i < PizzaId.length; i++) {

                if (PizzaId[i] == UniquePizzaID[x]) {

                    CombinedRating[x] = CombinedRating[x] + Rating[i];
                    Count[x] = Count[x] + 1;
                }

            }
        }



        //Get average Pizza of Ratings
        for (i = 0; i < UniquePizzaID.length; i++) {

            FinalRatings[i] = CombinedRating[i] / Count[i];

            graphData[i] = {
                label: Name[i],
                y: FinalRatings[i]
            };
        }

        //console.log("Rating: " + Rating);
        //console.log("PizzaId: " + PizzaId);
        //console.log("UniquePizzaID: " + UniquePizzaID);
        //console.log("Count: " + Count);
        //console.log("CombinedRating: " + CombinedRating);
        //console.log("FinalRatings: " + FinalRatings);
        //console.log(graphData);


        var options1 = {
            animationEnabled: true,
            title: {
                text: "Pizza Popularity Ratings"
            },
            axisX: {
                labelFontSize: 14
            },
            axisY: {
                maximum: 5,
                labelFontSize: 14
            },
            data: [{
                type: "column",
                dataPoints: graphData
            }]
        };


        $("#tabs").tabs({
            create: function (event, ui) {
                //Render Charts after tabs have been created.
                $("#chartContainer1").CanvasJSChart(options1);
            },
            activate: function (event, ui) {
                //Updates the chart to its container size if it has changed.
                ui.newPanel.children().first().CanvasJSChart().render();
            }
        });


    });

});

