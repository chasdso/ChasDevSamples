const buildHistoryUrl = 'https://dev.azure.com/columbia1938/ODP-Retail/_apis/build/builds?api-version=5.0';
const pipelinesUrl ='https://dev.azure.com/columbia1938/ODP-Retail/_apis/pipelines';

function getBuildInfo(){
  //fetch(pipelinesUrl)
  fetch('./Assets/JSON/pipelines.json')
  .then(response => response.json())
  .then(json => createHTML(json));
}
function createHTML(buildData){
  var template = document.getElementById("pipelineInfo").innerHTML;
  var compiledtemplate = Handlebars.compile(template);
  var genHTML = compiledtemplate(buildData);
  var buildContainer = document.getElementById("pipelineContainer");
  buildContainer.innerHTML=genHTML;
}
function toggle(source) {
  checkboxes = document.getElementsByName('pipelines');
  for(var i=0, n=checkboxes.length;i<n;i++) {
    checkboxes[i].checked = source.checked;
  }
}

function init(activity)
    {
      var selected = new Array();
      //var i = 0;
      $(document).ready(function() {

        $("input:checkbox[name=pipelines]:checked").each(function() {
          if (activity == 'suspend')
            { 
              //POST 	https://management.azure.com/subscriptions/{SubscriptionID}/resourcegroups/{ResourceGroupName}/providers/Microsoft.DataFactory/datafactories/{DataFactoryName}/datapipelines/{PipelineName}/pause?api-version={api-version}
              //testing: https://management.azure.com/subscriptions/19e28071-4309-4ccf-849c-3dc88e0be4a2/resourcegroups/res-generic-in/providers/Microsoft.DataFactory/datafactories/ODP-Retail/datapipelines/_Master/pause?api-version=5.0
              
              var suspendPipeline =$(this).val();
              var resourceGroup = 'res-generic-in';
              var subscriptionID = '19e28071-4309-4ccf-849c-3dc88e0be4a2';
              var dataFactoryName = 'ODP-Retail';
              var apiVersion = '5.0';
              var suspendPOST = 'https://management.azure.com/subscriptions/' + subscriptionID + '/resourcegroups/' + resourceGroup + '/providers/Microsoft.DataFactory/datafactories/' + dataFactoryName + '/datapipelines/' + suspendPipeline + '/pause?api-version=' + apiVersion + '';
              $('#status').append(suspendPOST);
              console.log(suspendPOST);
              fetch(resumePOST, {
                method: 'post',
                mode: 'cors',
                credentials: 'same-origin',                
                headers:{
                  'x-ms-client-request-id': '',
                },
                body: ''
                }).then(function(response) {
                  $('#status').append(response);
                  console.log(response);
                })
              
            }
          else if (activity == 'resume') 
            {
              //POST 	https://management.azure.com/subscriptions/{SubscriptionID}/resourcegroups/{ResourceGroupName}/providers/Microsoft.DataFactory/datafactories/{DataFactoryName}/datapipelines/{PipelineName}/resume?api-version={api-version}
              //testing: https://management.azure.com/subscriptions/19e28071-4309-4ccf-849c-3dc88e0be4a2/resourcegroups/res-generic-in/providers/Microsoft.DataFactory/datafactories/ODP-Retail/datapipelines/_Master/resume?api-version=5.0
              var resumePipeline =$(this).val();
              var resourceGroup = 'res-generic-in';
              var subscriptionID = '19e28071-4309-4ccf-849c-3dc88e0be4a2';
              var dataFactoryName = 'ODP-Retail';
              var apiVersion = '5.0';
              var resumePOST = 'https://management.azure.com/subscriptions/' + subscriptionID + '/resourcegroups/' + resourceGroup + '/providers/Microsoft.DataFactory/datafactories/' + dataFactoryName + '/datapipelines/' + resumePipeline + '/resume?api-version=' + apiVersion + '';
              $('#status').append(resumePOST);
              console.log(resumePOST);
              fetch(resumePOST, {
                method: 'post',
                mode: 'cors',
                credentials: 'same-origin',                
                headers:{
                  'x-ms-client-request-id': '',
                },
                body: ''
                }).then(function(response) {
                $('#status').append(response);
                console.log(response);
                })
            }
        });

      });
    }


