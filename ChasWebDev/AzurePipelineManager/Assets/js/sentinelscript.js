//Making Azure REST API calls with Postman tutorial gives you an idea of the two calls: https://www.youtube.com/watch?v=ujzrq8Fg9Gc
//Here is the first call, it will return the bearerToken, swap client_id with application ID and client_secret with your key (from https://docs.microsoft.com/en-us/azure/active-directory/develop/v1-oauth2-client-creds-grant-flow#request-an-access-token)

// POST /<tenant_id>/oauth2/token HTTP/1.1
// Host: login.microsoftonline.com
// Content-Type: application/x-www-form-urlencoded
// grant_type=client_credentials&client_id=625bc9f6-3bf6-4b6d-94ba-e97cf07a22de&client_secret=qkDwDJlDfig2IpeuUZYKH1Wb8q1V0ju6sILxQQqhJ+s=&resource=https%3A%2F%2Fservice.contoso.com%2F

// To make the Azure REST API call, you will need the bearerToken from above, and the following:
// tenant_id:
// grant_type: client_credentials
// client_id: 
// client_secret:
// subscriptionId:
// resource: 

//Chas PAT for testing
//const chasPAT = 'hvwze5otuhb5schq57f5omhlw4n6n3qsqdrywvaljjbqbrxqzm3q';
//const buildHistoryUrl = 'https://dev.azure.com/columbia1938/ODP-Retail/_apis/build/builds?api-version=5.0';
const pipelinesUrl ='https://dev.azure.com/columbia1938/ODP-Retail/_apis/pipelines';
const resourceAzure = 'https://management.azure.com';
const tenantID = 'bacbd475-b9da-43fa-958c-ed27e9d42d0e';
const tokenRequestURL = 'https://login.microsoftonline.com/' + tenant_id + '/oauth2/token';
//Columbia dev/test subscription, this shouldn't be needed to access the VSTS Azure REST API:
const subscriptionID = '19e28071-4309-4ccf-849c-3dc88e0be4a2';
var buildID = '#Generic.Inbound-20190606.2';
//var buildID = '#20190606.2';
var patchBuildPipelineQueue = 'https://dev.azure.com/columbia1938/ODP-Retail/_apis/build/builds/' + buildID + '&api-version=5.0';
//Sentinel registered app ID --Unfortunately Sentinel app NOT given contributor rights yet to subscription, so this won't work
//var appID = 'c2647fda-1fd3-4c49-98c3-a49af43def55';
var appID ='';
//Sentinel app key -- Unfortunately Sentinel app NOT given contributor rights yet to subscription, so this won't work
//var secret = 'iq.1OL153wud-EIeEQJJWMKaJLjaX]e.';
var clientSecret = '';
var bearerToken = '';
var password = chasPAT;
var username ='';

function getBearerToken(){
  fetch(tokenRequestURL, {
    method: 'Post',
    mode: 'cors',
    headers:{
      //+ base64.encode(username + ":" + password)
      //'Authorization': 'Basic ' + (username + ":" + password),
      'Content-Type': 'application/json'
     },
    body: {
      'grant_type': 'client_credentials',
      'client_id': appID,
      'client_secret': clientSecret,
      'resource': resourceAzure
    }
  })  
      .then(response => response.json())
      .then(data => bearerToken = data) 
      .then(json => console.log(json))   
}

function init(activity)
    {
      getBearerToken();
      
      $(document).ready(function() {

        $("input:checkbox[name=pipelines]:checked").each(function() {

          switch(activity) {
            case 'pause':
              
              break;
            case 'resume':
              {
                $('#status').append("&#10;" + patchBuildPipelineQueue);
                console.log(patchBuildPipelineQueue);
                fetch(patchBuildPipelineQueue, {
                  method: 'PATCH',
                  mode: 'cors',
                  headers:{
                  'Authorization': 'Bearer' + bearerToken
                  },
                  body: {
                    'grant_type': 'client_credentials',
                    'client_id': appID,
                    'client_secret': clientSecret,
                    "buildNumber": buildID,
                    "buildNumberRevision":1,
                    "definition":
                    {
                        "id":1,
                        "createdDate":null,
                        "queueStatus":"enabled"
                    }
                }
                  })
                  .then((response) => {
                  console.log(response);
                    //$('#status').append("&#10;" + response.text);
                    // response.json().then((data) => {
                    //   //$('#status').append("&#10;" + data);  
                    //   console.log(data);
                        
                        
                  })
                  
                  // .then(function(response) {
                  //   $('#status').append("&#10;" + response);
                  //   console.log(response.text);
                  //})
              };
              break;
              default:
              // code block
            } 
        });

      });
    }
    function getBuildInfo(){
      //fetch(pipelinesUrl)
      fetch('./Assets/JSON/pipelines.json')
      .then(response => response.json())
      .then(json => createHTML(json));
    }
    function openForm() {
      document.getElementById("loginForm").style.display = "block";
    }
    
    function closeForm() {
      document.getElementById("loginForm").style.display = "none";
    } 
    function processLogin(){
    
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
    
    


