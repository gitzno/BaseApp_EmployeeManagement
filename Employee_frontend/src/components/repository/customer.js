export default class customerService{
    linkapi;
    constructor(link){
        this.linkapi = link;
    }
    getApiService(){
        try {
            fetch(this.linkapi)
              .then((res) => res.json())
              .then((data) => {
                console.log(data);
                return data;
              });
          } catch (error) {
            console.error(error);
          }
    }
    validateService(){
      
    }
}