window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})


const functionApiUrl = 'https://getresumecounterke.azurewebsites.net/api/GetResumeCounter?code=tC57Plip6/sjX6MfzdQ/Ml3t1t8DE4TngaWauxkV4lU/hweuGsJqEw==';
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count =  response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}