pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
				powershell label: '', script: '''dotnet restore; dotnet build'''
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying..'
                powershell label: '', script: '''dotnet restore; dotnet publish -c Release'''
		archiveArtifacts artifacts: 'PSOpenLocationCode/bin/Release/netcoreapp2.1/publish/**'
            }
        }

    }
}
