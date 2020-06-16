# Platform API Test

![.NET Core](https://github.com/rick-strand/platform-api-test/workflows/.NET%20Core/badge.svg)

Summary:
- Simple api created in .Net Core run as a docker container and the CI pipeline builds a docker image and pushes to Docker Hub

- Utilizing Github Actions to:
- Build using .Net Core CLI
- Run (basic) integration tests
- Build and push to Docker Hub

### Table of Contents

- Pre-requisites
- How to run the app?
- How to build the app?
- CI pipeline and Versioning
- Next Steps


### 1 Pre-requisites

- Docker engine
- .Net Core SDK
- .Net Core Runtime
- git

### 2 How to run the app?

#### 2.1 Docker

The Github Actions pipeline in this project publishes a docker image to docker hub.

##### 2.1.1 Latest

Execute the following command to run the latest version of this app (not recommended for production, use a specific version)

```
docker run -it -p 3000:80 rickstrand/rickstrand:latest  
```

The above command should result in a log line like

```
Now listening on: http://[::]:80
```
this means the API has started successfully and now you can access it on `http://localhost:3000/version`


#### 2.2 .Net Core


*NOTE:* For this you will need to have `git`, `.Net Core Runtime` and `.Net Core SDK` installed and configured on your machine.

Clone the repo

```
git clone https://github.com/rick-strand/platform-api-test.git
```

From the root of the project
```
cd platform-api
dotnet run
```

The above command should result in log line like
```
Now listening on: http://localhost:5000
```

This means the API has started successfully and now you can access it on `http://localhost:5000/version`

#### 2.3 Kubernetes

*NOTE:* For this you will need to have `git`, `.Net Core Runtime` and `.Net Core SDK` installed and configured on your machine.

Clone the repo

```
git clone https://github.com/rick-strand/platform-api-test.git
```

From the root of the project
```
cd platform-api
```

Create the deployment in Kubernetes
```
kubectl create -f deployment.yaml
```

Create the service in Kubernetes
```
kubectl create -f service.yaml
```

Create the namespace in Kubernetes
```
kubectl create -f namespace-technical-test.json
```

Add the deployment to the namespace "technical-test" in Docker Desktop
```
kubectl config set-context technical-test --namespace=technical-test --cluster=docker-desktop --user=docker-desktop 
```

Check to see that the deployment of the app is in the namespace "technical-test"
```
kubectl config view
```


### 3 CI Pipeline and Versioning

This project has Github Actions CI/CD pipeline enabled to build the application and publish the docker image to Docker Hub. 

- Push docker image when merged / pushed to master branch and upon pull requests. 
- Build using .Net Core CLI
- Run (basic) integration tests
- Build using `latest` as version for both app and docker image.
- Push docker image to Docker Hub.

### 4 Next steps

- Security: SSL, Api key etc.
- Currently when a pull request is made it builds, tests and deploys to Docker Hub. I'll need to figure how to ensure builds and tests are run but only deploy to Docker Hub upon a successful merge to master. 

It was good fun working on this little project!


