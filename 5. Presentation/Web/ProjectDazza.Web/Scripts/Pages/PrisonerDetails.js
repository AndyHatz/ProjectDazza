$(function ()
{
    var serverdata = $.parseJSON($("#jsondata").val()); // Get data from hidden field
    model = kendo.observable(serverdata); // Create JS model from passed in ViewModel


    // Add extra functionality to the model here
    model.HandleSubmit = function ()
    {
        var jsonModel = this.toJSON();

        // Strip off reference data
        delete jsonModel.ReferenceData;

        $("#jsondata").val(JSON.stringify(jsonModel)); // Put model into jsondata to be submitted

        return true; // Continue with Submit
    }


    kendo.bind($("#kendoform"), model); // Bind once to a DOM element
});