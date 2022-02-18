import axios from 'axios';

export default class PresentationService {
    async get(){
        return new Promise((resolve) => {
            axios.get("https://localhost:5001/api/sessions/100", {
                headers : {

                }
            }).then((response => {
                resolve(response.data)
            }))
        })
    }
    
    async getPresentation(idSession, idPanelist){
        return new Promise((resolve) => {
            axios.get("https://localhost:5001/api/presentation/"+ idSession +"/" + idPanelist, {
                headers : {

                }
            }).then((response => {
                resolve(response.data)
            }))
        })
    }

}