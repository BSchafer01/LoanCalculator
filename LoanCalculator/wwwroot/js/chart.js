function GenerateLineGraph(monthlyResults) {
    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create("chartdiv", am4charts.XYChart);
    chart.data = monthlyResults;

    var series = [];

    // Create axes
    var dateAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    dateAxis.dataFields.category = "month";

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.title.text = "Total Payment ($)";

    var interestAxis = chart.yAxes.push(new am4charts.ValueAxis());
    interestAxis.syncWithAxis = valueAxis;
    interestAxis.renderer.opposite = true;
    interestAxis.title.text = "Interest Payment ($)"


    //Format y axis to money
    chart.numberFormatter.numberFormat = "$#,###.00";


    //Format x axis to int
    dateAxis.numberFormatter = new am4core.NumberFormatter();
    dateAxis.numberFormatter.numberFormat = "#.";





    series.push(createSeries("additionalTotalPrincipal", "Add'l: Total", valueAxis, "Add'l-Total Paid: "));
    series.push(createSeries("totalPaid", "Base: Total", valueAxis, "Base-Total Paid: "));
    series.push(createSeries("interestPayment", "Base: Interest", interestAxis, "Base-Interest Paid: "));
    series.push(createSeries("additionalInterest", "Add'l: Interest", interestAxis, "Add'l-Interest Paid: "));




     //Create series
    function createSeries(s, name, axis, tooltip) {
        var series = chart.series.push(new am4charts.LineSeries());
        series.dataFields.valueY = s;
        series.dataFields.categoryX = "month";
        series.name = name;
        series.yAxis = axis;
        series.tooltipText = tooltip + "{" + s + "}"
        //series.legendSettings.valueText = "{"+s+"}";
        series.strokeWidth = 2;
        series.minBulletDistance = 15;

        // Make bullets grow on hover
        var bullet = series.bullets.push(new am4charts.CircleBullet());
        bullet.circle.strokeWidth = 2;
        bullet.circle.radius = 4;
        bullet.circle.fill = am4core.color("#fff");

        var bullethover = bullet.states.create("hover");
        bullethover.properties.scale = 1.3;




        var segment = series.segments.template;
        segment.interactionsEnabled = true;

        var hoverState = segment.states.create("hover");
        hoverState.properties.strokeWidth = 3;
        segment.strokeWidth = 1;

        var dimmed = segment.states.create("dimmed");
        dimmed.properties.stroke = am4core.color("#dadada");

        segment.events.on("over", function (event) {
            processOver(event.target.parent.parent.parent);
        });

        segment.events.on("out", function (event) {
            processOut(event.target.parent.parent.parent);
        });


        
        return series;
    }

    // Make a zooming cursor
    chart.cursor = new am4charts.XYCursor();
    chart.cursor.behavior = "zoomX";

    // Make a legend
    chart.legend = new am4charts.Legend();
    chart.legend.position = "bottom";
    chart.legend.itemContainers.template.events.on("over", function (event) {
        processOver(event.target.dataItem.dataContext);
    })

    chart.legend.itemContainers.template.events.on("out", function (event) {
        processOut(event.target.dataItem.dataContext);
    })

    function processOver(hoveredSeries) {
        hoveredSeries.toFront();

        hoveredSeries.segments.each(function (segment) {
            segment.setState("hover");
        })

        chart.series.each(function (series) {
            if (series != hoveredSeries) {
                series.segments.each(function (segment) {
                    segment.setState("dimmed");
                })
                series.bulletsContainer.setState("dimmed");
            }
        });
    }

    function processOut(hoveredSeries) {
        chart.series.each(function (series) {
            series.segments.each(function (segment) {
                segment.setState("default");
            })
            series.bulletsContainer.setState("default");
        });
    }

}
