# How-to-create-a-Pie-Chart-in-WinUI

The WinUI Pie Chart is a circular graph that is ideal for displaying proportional values in various categories. This section explains how to create WinUI Pie Charts.

The User Guide Documentation helps you to acquire more knowledge on charts and their features. You can also refer to the Feature Tour site to get an overview of all the features in the chart.

![.NET MAUI Pie Chart](https://user-images.githubusercontent.com/63223423/144578562-89a60e58-4001-4eed-98b3-40cccbaf7b98.png)

### Step 1: 
Create a simple project using the instructions given in the Getting Started with your first WinUI app documentation.

### Step 2: 
Add Syncfusion.Chart.WinUI NuGet to the project and import the SfCircularChart namespace as follows.

**[XAML]**
```
xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
```
**[C#]**
```
using Syncfusion.UI.Xaml.Charts;
```
### Step 3: 
Initialize an empty circular chart and set it as content.

**[XAML]**
```
<chart:SfCircularChart>
. . . 
</chart:SfCircularChart>
```
**[C#]**
```
SfCircularChart chart = new SfCircularChart();
. . .
this.Content = chart;
```
### Step 4: 
Initialize a data model that represents a data point for the WinUI Pie chart.

**[C#]**
```
public class Model
{
    public string Country{ get; set; }

    public double Counts { get; set; }

    public Model(string name , double count)
    {
        Country= name;
        Counts = count;
    }
}
```
### Step 5: 
Create a ViewModel class with a data collection property using the above model and initialize a list of objects as shown in the following code sample.

**[C#]**
```
public class ViewModel
{
    public ObservableCollection<Model> Data { get; set; }

    public ViewModel()
    {
        Data = new ObservableCollection<Model>()
        {
            new Model("Algeria", 28),
            new Model("Australia", 14),
            new Model("Bolivia", 31),
            new Model("Cambodia", 77),
            new Model("Canada", 19),
        };
    }
}
```
### Step 6: 
Set the ViewModel instance as the DataContext of the chart; this is done to bind properties of ViewModel to the SfCircularChart.

> Note: Add namespace of ViewModel class to your XAML page, if you prefer to set DataContext in XAML.

**[XAML]**
```
xmlns:viewModel="using:CircularChartDesktop"
. . .
<chart:SfCircularChart>
    <chart:SfCircularChart.DataContext >
        <viewModel:ViewModel/>
    </chart:SfCircularChart.DataContext >
</chart:SfCircularChart>
```
**[C#]**
```
SfCircularChart chart = new SfCircularChart();
chart.DataContext = new ViewModel();
```
### Step 7: 
Populate the chart with data.

As we are going to visualize the comparison of the annual population of various countries in the data model, add PieSeries to SfCircularChart.Series property, and then bind the Data property of the above ViewModel to the PieSeries ItemsSource property as shown in the following code sample.

> Note: Need to set XBindingPath and YBindingPath properties so that series will fetch values from the respective properties in the data model to plot the series.

**[XAML]**
```
<chart:SfCircularChart>
…
    <chart:SfCircularChart.DataContext>
        <viewModel:ViewModel/>
    </chart:SfCircularChart.DataContext>

<chart:SfCircularChart.Series>
    <chart:PieSeries ItemsSource="{Binding Data}"
                        XBindingPath="Country" 
                        YBindingPath="Counts"
                       ShowDataLabels="True">
    </chart:PieSeries>
</chart:SfCircularChart.Series>
…
</chart:SfCircularChart>
```
**[C#]**
```
SfCircularChart chart = new SfCircularChart ();
chart.BindingContext = new ViewModel();
. . .
var binding = new Binding() { Path = "Data" };
var series = new PieSeries()
{
XBindingPath = " Country",
YBindingPath = "Counts",
ShowDataLabels = true
};

series.SetBinding(ChartSeries.ItemsSourceProperty, binding);
chart.Series.Add(series);
```
