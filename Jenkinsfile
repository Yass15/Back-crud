pipeline {
    agent {
        docker {
            image 'node:14-alpine'
            label 'my-custom-label'
            args '--user node'
        }
    }
    
    triggers {
        githubPush()
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                bat 'docker-compose -f C:/Users/Yassi/OneDrive/Bureau/PFE-SPARK/docker-compose.yml up --build -d'
                waitUntilServicesReady
            }
        }
    }

    post {
        success {
            bat 'echo "success"'
        }
        failure {
            bat 'echo "Build failed"'
        }
    }
}
