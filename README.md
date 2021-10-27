# Blazor ICalendar

A Blazor `ICalendar` control that uses the `Ical.Net` package.

[ICalendar](https://en.wikipedia.org/wiki/ICalendar) is a file specification for calendar information, that is supported by many calendar applications (e.g. Outlook, Google, Apple). It uses a `.ics` extension.

This library uses the [`Ical.Net`](https://github.com/rianjs/ical.net) package to handle the ICalendar logic and then creates an [anchor tag (a)](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/a) with a [data-url](https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/Data_URIs) that contains the `.ics` file.

If a user clicks the link, the browser will download the `.ics` file - this file if opened will usually add a calendar entry to the user's preferred calendar.

### Usage

There are two components in the library: `<ICalendar>` which takes a `Ical.Net.Calendar` object as the data source, and `<ICalendarQuick>` for simple scenarios with dates and descriptions.

#### ICalendar

Example:
```html
<ICalendar Calendar=@myCal Filename="example.ics">Add to Calendar</ICalendar>
```
Note that both components render as anchor tags `<a>` so the content is the link content. The C# code behind this is as follows:
```c#

   Calendar myCal;
    
   protected override void OnInitialized()
   {
      var start = DateTime.Now.AddHours(1);
      var end = start.AddHours(1);
      var e = new CalendarEvent
            {
                Start = new CalDateTime(start),
                End = new CalDateTime(end),
                Description = "test1",
                Summary = "Name"
            };
      myCal = new Calendar();
      myCal.Events.Add(e);
   }
```
Note that if the `Calendar` parameter is not set, the link will not be rendered.

#### ICalendarQuick

Example:
```html
<ICalendarQuick Start=@start End=@end Filename="quick.ics"
                Description="detail goes here" 
                Summary="Appointment name">Add to Calendar</ICalendarQuick>
```
Both the `Start` and `End` must be set for the link to show. 

Code behind just sets the two times:
```c#
   DateTime start = DateTime.Now.AddHours(1);
   DateTime end = DateTime.Now.AddHours(2);
    
```